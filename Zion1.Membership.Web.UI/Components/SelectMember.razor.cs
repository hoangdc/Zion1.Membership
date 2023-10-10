using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Zion1.Common.API.Consumer;
using Zion1.Membership.Web.UI.Models;

namespace Zion1.Membership.Web.UI.Components
{
    public partial class SelectMember
    {
        public List<Member> MemberList { get; set; } = new();

        private ApiConsumer _apiConsumer = new ApiConsumer(ApiHelper.GetApiSettings());

        public IEnumerable<Member> SelectedMembers { get; set; } = new List<Member>();

        [Parameter]
        public Group SelectedGroup { get; set; } = new();

        public TelerikNotification NotificationResult { get; set; } = new();
        public string MessageResult { get; set; } = string.Empty;


        protected override async Task OnInitializedAsync()
        {
            await GetMemberList();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender && !string.IsNullOrEmpty(MessageResult.Trim()))
            {
                NotificationResult.HideAll();
                NotificationResult.Show(new NotificationModel
                {
                    Text = MessageResult,
                    ThemeColor = "success",
                    CloseAfter = 3000
                });
                MessageResult = string.Empty;
            }

            return base.OnAfterRenderAsync(firstRender);
        }

        private async Task GetMemberList()
        {
            var restResponse = await _apiConsumer.ExecuteAsync("GetMemberList");
            MemberList = restResponse.Convert<List<Member>>();

        }

        private async Task AssignMembersToGroup()
        {
            foreach(var member in SelectedMembers)
            {
                var memberInGroup = new MemberInGroup() { GroupId = SelectedGroup.Id, MemberId = member.Id };
                _apiConsumer.Body = memberInGroup;
                var restResponse = await _apiConsumer.ExecuteAsync("AssignMemberToGroup");
            }
            MessageResult = "Success";
        }
    }
}
