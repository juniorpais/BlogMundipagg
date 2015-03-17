using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

using BlogMundiPagg.Web.Controllers;
using BlogMundiPagg.Repository.Entities;
using BlogMundiPagg.Repository.DAL.Repository;
using System.Web.Mvc;



namespace IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IUsuarioRepository mokcUsuario = new Moq.Mock<IUsuarioRepository>().Object;

            var userController = new UsuarioController();

            userController.repUsuario = mokcUsuario;

            var result = userController.Create(
                new Usuario()
                    {
                        Nome = "Bartholomeu Salvattori",
                        Email = "barth@gmail.com",
                        Senha = "1234567"

                    });

                        


        }
    }
}
