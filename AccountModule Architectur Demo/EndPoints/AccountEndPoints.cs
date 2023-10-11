using Account.Service.DTOs;
using Account.Service.Entities.Domain;
using Account.Service.Entities.Projections;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Wolverine;
using Wolverine.Http;
using Wolverine.Runtime;

namespace AccountModule_Architectur_Demo.EndPoints
{
    public class AccountEndPoints
    {
        private readonly IMessageBus _messageBus;
        public AccountEndPoints(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }
        [WolverinePost("CreateAccount")]
        public async Task<ActionResult> CreateAccount(AccountDTO accountvm)
        {
            await _messageBus.SendAsync(accountvm);
            return new ObjectResult("Account Created Successfully");
        }
        [WolverinePut("UpdateAccount")]
        public async Task<ActionResult> UpdateAccount(UpdateAccountDTO updateAccount)
        {
            await _messageBus.SendAsync(updateAccount);
            return new ObjectResult("Account Updated Successfully");
        }
        [WolverineGet("GetAccount/{Id}")]
        public async Task<AccountHolderDetails> GetAccount([FromRoute]Guid Id)
        {
            var details = await _messageBus.InvokeAsync<AccountHolderDetails>(Id);
            return details;
        }
        [WolverinePost("CreateAccountHolderIdentityProofs")]
        public async Task<ActionResult> AccountHolderIdentityProofs(AccountHolderIdentityProofDTO accountHolderAddressDTO)
        {
            await _messageBus.SendAsync(accountHolderAddressDTO);
            return new ObjectResult("Address Created Successfully");
        }
       
        [WolverineGet("GetAccountList")]
        public async Task<List<AccountHolderDetails>> GetAccountList(GetAccountList getAccountList)
        {
            var details = await _messageBus.InvokeAsync<List<AccountHolderDetails>>(getAccountList);
            return details;
        }
        //[WolverinePost("DeleteAccount/{Id}")]
        //public async Task DeleteAccount([FromRoute] Guid Id)
        //{
        //     await _messageBus.SendAsync(Id);
         
        //}
        [WolverinePost("DeleteAccount")]
        public async Task DeleteAccount(DeleteAccountDTO delete)
        {
             await _messageBus.SendAsync(delete);
         
        }
    }
}
