using API.Gate.GraphQl.Exceptions;
using DAL;
using Domain.Core.Sells.Service;
using Domain.Core.Users;

namespace API.Gate.GraphQl.Mutations
{
    [ExtendObjectType("Mutations")]
    public class ServiceMutations
    {
        private readonly Context context;
        private readonly Repository<Service> repository;

        public ServiceMutations([Service] Context context)
        {
            this.context = context;
            this.repository = new Repository<Service>(context);
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Service> CreateService(Service service)
        {
            await this.repository.CreateAsync(service);
            return service;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Service> UpdateService(Service service)
        {
            try
            {
                await this.repository.UpdateAsync(service);
                return service;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Service with id == {service.Id} not found", service.Id);
            }
            catch
            {
                throw;
            }
        }


        [UseFiltering]
        public async Task<Service> RemoveService(Service service)
        {
            try
            {
                await this.repository.DeleteAsync(service.Id);
                return service;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Service with id == {service.Id} not found", service.Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
