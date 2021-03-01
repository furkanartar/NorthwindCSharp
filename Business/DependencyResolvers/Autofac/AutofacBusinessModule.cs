using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();//IProductService istendiği zaman ProductManager'ın 1 tane instance'ı oluşturulup herkese o verilecek.
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); //Çalışan uygulama içerisindeki 

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() //implemente edilmiş interface'leri buluyor
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()//onlar için AspectInterceptorSelector'ı çağırıyor.
                }).SingleInstance();
        }
    }
}//son kısım sanırım bunların aspect (attirbute'u) var mı diye kontrol ediyor