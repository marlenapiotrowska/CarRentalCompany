using CarRentalCompany.Core.Dto.RequestModels;
using CarRentalCompany.Core.Dto.ResponseModels;
using CarRentalCompany.Frontend.DataAccess.Http;
using CarRentalCompany.Frontend.Domain.Interfaces;
using CarRentalCompany.Frontend.Domain.ValueObjects;

namespace CarRentalCompany.Frontend.DataAccess
{
    public class CarRentalClient : RequestService, ICarReceiptFormRepository, IClientRepository
    {
        private const string _apiPath = "http://localhost:5251";

        public async Task<ExecutionResultGeneric<CarReceiptFormDto>> CreateCarReceiptForm(string type, Guid clientId)
        {
            var request = new Request<CreateCarReceiptFormRequestModel, CarReceiptFormDto>()
            {
                Path = $"{_apiPath}/forms",
                Method = HttpMethod.Post,
                Content = new CreateCarReceiptFormRequestModel()
                {
                    Type = type,
                    ClientId = clientId
                }
            };

            return await SendAsync(request);
        }

        public async Task<ExecutionResultGeneric<IEnumerable<ClientDto>>> GetAllClients()
        {
            var request = new Request<HttpRequestMessage, IEnumerable<ClientDto>>()
            {
                Path = $"{_apiPath}/clients",
                Method = HttpMethod.Get,
            };

            return await SendAsync(request);
        }
    }
}
