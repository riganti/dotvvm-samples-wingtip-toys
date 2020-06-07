using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Owin;
using System.Web;
using System.Web.Hosting;
using System.Web.SessionState;
using WingtipToys.DotvvmSite;

[assembly: OwinStartupAttribute(typeof(WingtipToys.Startup))]
namespace WingtipToys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use((context, next) =>
            {
                var httpContext = context.Get<HttpContextBase>(typeof(HttpContextBase).FullName);
                httpContext.SetSessionStateBehavior(SessionStateBehavior.Required);
                return next();
            });
            app.UseStageMarker(PipelineStage.MapHandler);

            ConfigureAuth(app);

            app.UseDotVVM<DotvvmStartup>(HostingEnvironment.ApplicationPhysicalPath,
                useErrorPages: HostingEnvironment.IsDevelopmentEnvironment, debug: HostingEnvironment.IsDevelopmentEnvironment);
        }
    }
}
