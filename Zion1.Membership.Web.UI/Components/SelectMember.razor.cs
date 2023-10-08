using Telerik.Blazor.Components;
using Zion1.Common.API.Consumer;
using Zion1.Membership.Web.UI.Models;

namespace Zion1.Membership.Web.UI.Components
{
    public partial class SelectMember
    {
        public List<Member> MemberList { get; set; } = new List<Member>();

        private ApiConsumer _apiConsumer = new ApiConsumer(ApiHelper.GetApiSettings());

        protected override async Task OnInitializedAsync()
        {
            await GetMemberList();
        }

        private async Task GetMemberList()
        {
            var restResponse = await _apiConsumer.ExecuteAsync("GetMemberList");
            MemberList = restResponse.Convert<List<Member>>();
        }
    }
}
