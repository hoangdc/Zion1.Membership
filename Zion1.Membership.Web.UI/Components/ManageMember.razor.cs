using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using Zion1.Membership.Web.UI.Models;
using Zion1.Common.API.Consumer;

namespace Zion1.Membership.Web.UI.Components
{
    public partial class ManageMember
    {
        public List<Member> memberList { get; set; } = new List<Member>();
        public string MessageResult { get; set; } = string.Empty;

        private ApiConsumer _apiConsumer = new ApiConsumer(ApiHelper.GetApiSettings());

        public ManageMember()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            await GetMemberList();
            await Task.Delay(2000);
        }

        private async Task GetMemberList()
        {
            var restResponse = await _apiConsumer.ExecuteAsync("GetMemberList");
            memberList = restResponse.Convert<List<Member>>();
        }

        private async Task CreateMember(GridCommandEventArgs args)
        {
            Member? memberInfo = args.Item as Member;

            if (memberInfo != null)
            {

                _apiConsumer.Body = memberInfo;
                var response = await _apiConsumer.ExecuteAsync("CreateMember");

                if (!response.IsSuccessStatusCode)
                {
                    //Logic for handling unsuccessful response
                    MessageResult = response.Content;
                }
                else
                {
                    MessageResult = "Success";
                }
            }
            else
            {
                MessageResult = "Member info is null";
            }

            //Reload Data
            await GetMemberList();
        }

        private async Task UpdateMember(GridCommandEventArgs args)
        {
            Member? memberInfo = args.Item as Member;

            if (memberInfo != null)
            {
                _apiConsumer.Body = memberInfo;
                var response = await _apiConsumer.ExecuteAsync("UpdateMember");

                if (!response.IsSuccessStatusCode)
                {
                    //Logic for handling unsuccessful response
                    MessageResult = response.StatusCode + " - " + response.Content.ToString();
                }
                else
                {
                    MessageResult = "Success";
                }
            }
            else
            {
                MessageResult = "Member info is null";
            }

            //Reload Data
            await GetMemberList();
        }

        private async Task DeleteMember(GridCommandEventArgs args)
        {
            Member? memberInfo = args.Item as Member;

            if (memberInfo != null)
            {

                _apiConsumer.Params.Add("Id", memberInfo.Id.ToString());
                var response = await _apiConsumer.ExecuteAsync("DeleteMember");

                if (!response.IsSuccessStatusCode)
                {
                    //Logic for handling unsuccessful response
                    MessageResult = response.StatusCode + " - " + response.Content.ToString();
                }
                else
                {
                    MessageResult = "Success";
                }
            }
            else
            {
                MessageResult = "Member info is null";
            }

            //Reload Data
            await GetMemberList();
        }
    }
}
