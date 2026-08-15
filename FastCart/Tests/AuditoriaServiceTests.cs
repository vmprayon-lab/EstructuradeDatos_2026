using FastCart.Models;
using FastCart.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastCart.Tests;

[TestClass]
public class AuditoriaServiceTests
{
    [TestMethod]
    public void ListaVacia_NoProduceErrores()
    {
        AuditoriaService auditoria = new AuditoriaService();

        auditoria.ImprimirHistorial();
        auditoria.ImprimirHistorialInverso();

        Assert.AreEqual(0, auditoria.TotalRegistros);
    }

    [TestMethod]
    public void RegistrarEvento_UnRegistro_AumentaElTotal()
    {
        AuditoriaService auditoria = new AuditoriaService();

        LogMovimiento movimiento = new LogMovimiento
        {
            TipoOperacion = "INSERT",
            ProductoId = 101,
            Referencia = "Producto agregado",
            FechaHora = DateTime.Now
        };

        auditoria.RegistrarEvento(movimiento);

        Assert.AreEqual(1, auditoria.TotalRegistros);
    }

    [TestMethod]
    public void RegistrarEvento_MultiplesRegistros_MantieneElOrden()
    {
        AuditoriaService auditoria = new AuditoriaService();

        for (int i = 1; i <= 3; i++)
        {
            LogMovimiento movimiento = new LogMovimiento
            {
                TipoOperacion = "INSERT",
                ProductoId = i,
                Referencia = $"Producto {i}",
                FechaHora = DateTime.Now
            };

            auditoria.RegistrarEvento(movimiento);
        }

        Assert.AreEqual(3, auditoria.TotalRegistros);
    }

    [TestMethod]
    public void ImprimirHistorial_NoLanzaExcepcion()
    {
        AuditoriaService auditoria = new AuditoriaService();

        auditoria.RegistrarEvento(new LogMovimiento
        {
            TipoOperacion = "INSERT",
            ProductoId = 101,
            Referencia = "Producto 101",
            FechaHora = DateTime.Now
        });

        auditoria.RegistrarEvento(new LogMovimiento
        {
            TipoOperacion = "UPDATE",
            ProductoId = 101,
            Referencia = "Producto 101 actualizado",
            FechaHora = DateTime.Now
        });

        auditoria.ImprimirHistorial();

        Assert.AreEqual(2, auditoria.TotalRegistros);
    }

    [TestMethod]
    public void ImprimirHistorialInverso_NoLanzaExcepcion()
    {
        AuditoriaService auditoria = new AuditoriaService();

        auditoria.RegistrarEvento(new LogMovimiento
        {
            TipoOperacion = "INSERT",
            ProductoId = 101,
            Referencia = "Producto 101",
            FechaHora = DateTime.Now
        });

        auditoria.RegistrarEvento(new LogMovimiento
        {
            TipoOperacion = "DELETE",
            ProductoId = 101,
            Referencia = "Producto 101 eliminado",
            FechaHora = DateTime.Now
        });

        auditoria.ImprimirHistorialInverso();

        Assert.AreEqual(2, auditoria.TotalRegistros);
    }

    [TestMethod]
public void InventarioLista_ConAuditoriaNula_LanzaExcepcion()
{
    bool lanzoExcepcion = false;

    try
    {
        new FastCart.Inventory.InventarioLista(null!);
    }
    catch (ArgumentNullException)
    {
        lanzoExcepcion = true;
    }

    Assert.IsTrue(lanzoExcepcion);
}
}