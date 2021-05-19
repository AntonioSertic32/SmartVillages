using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVillages.Client.Pages.UserSign
{
    public class EmailConfirmationBase : ComponentBase
    {
        [Parameter] public string Code { get; set; }

        public bool IsValid { get; set; }

        protected async override Task OnInitializedAsync()
        {
            // pozvat [HttpPost("ConfirmEmail/{code}/{email}")]
            // ispis dobro/lose proslo

            // slanje maila da posalje pravi secret code (kreirati shared service i prebaciti tako na api sve..)
            // i locked property se mjenja u false




            // zakucat i ime kad se salje u mailu 
            //sredit codegenerator, neda slova i ima 9 brojeva + maknit viticaste zagrade -.-


            // ne zakuca emailconfirmationcode u bazu.. 
            // na komponenti emailconfirmation dodati i parametar email i osposobiti validaciju
        }
    }
}
