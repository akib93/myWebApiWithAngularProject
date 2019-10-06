using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;


using OnlineShoppingMvcApi.Models;
using OnlineShoppingMvcApi.Models.Repository;


namespace OnlineShoppingMvcApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            container.RegisterType<IDataAccessRepository<Category, int>, ClsCategoryDataAccessRepository>();
            container.RegisterType<IDataAccessRepository<Item, int>, ClsItemDataAccessRepository>();
            container.RegisterType<IDataAccessRepository<Supplier, int>, ClsSupplierDataAccessRepository>();
            container.RegisterType<IDataAccessRepository<Brand, int>, ClsBrandDataAccessRepository>();
            container.RegisterType<IDataAccessRepository<Purchase, int>, ClsPurchaseDataAccessRepository>();
            container.RegisterType<IDataAccessRepository<Customer, int>, ClsCustomerDataAccessRepository>();
            container.RegisterType<IDataAccessRepository<Stock, int>, ClsStockDataAccessRepository>();
            container.RegisterType<IDataAccessRepository<CancelOrder, int>, ClsCancelOrderDataAccessRepository>();
            container.RegisterType<IDataAccessRepository<OrderDetail, int>, ClsOrderDetailDataAccessRepository>();
            container.RegisterType<IDataAccessRepository<Payment, int>, ClsPaymentDataAccessRepository>();
            container.RegisterType<IDataAccessRepository<Shippment, int>, ClsShipmentDataAccessRepository>();



            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}