using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.Sitemap;
using Microsoft.Extensions.DependencyInjection;

namespace IranFilmPort.Application.Services.UserProjects.Commands.DeleteUserProject
{
    public class RequestDeleteUserProjectServiceDto
    {
        public Guid Id { get; set; }
    }
    public interface IDeleteUserProjectService
    {
        Task<ResultDto> Execute(RequestDeleteUserProjectServiceDto req);
    }
    public class DeleteUserProjectService : IDeleteUserProjectService
    {
        private readonly IDataBaseContext _context;
        private readonly IServiceProvider _serviceProvider;
        public DeleteUserProjectService(IDataBaseContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }
        public async Task<ResultDto> Execute(RequestDeleteUserProjectServiceDto req)
        {
            if (req == null || req.Id == Guid.Empty) { return new ResultDto { IsSuccess = false }; }

            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IDataBaseContext>();
                var sitemapFacade = scope.ServiceProvider.GetRequiredService<ISitemapService>();

                using (var transaction = await dbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        // get the data

                        var userProject = dbContext.UserProjects
                            .FirstOrDefault(p => p.Id == req.Id);
                        if (userProject == null) return new ResultDto { IsSuccess = false };
                        userProject.DeleteDateTime = DateTime.Now;

                        var output = await dbContext.SaveChangesAsync();

                        // sitemap ...
                        sitemapFacade.CreateOrUpdateSitemap();

                        if (output >= 0)
                        {
                            await transaction.CommitAsync();
                            return new ResultDto { IsSuccess = true };
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            return new ResultDto { IsSuccess = false };
                        }
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        return new ResultDto { IsSuccess = false };
                    }
                }
            }
        }
    }
}