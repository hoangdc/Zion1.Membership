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
            await GetAllMembers();
            await GetMembersByGroup();
        }

        private async Task GetAllMembers()
        {
            var restResponse = await _apiConsumer.ExecuteAsync("GetMemberList");
            MemberList = restResponse.Convert<List<Member>>();
        }

        private async Task GetMembersByGroup()
        {
            _apiConsumer.Params.Add("groupid", SelectedGroup.Id.ToString());
            var restResponse = await _apiConsumer.ExecuteAsync("GetMemberListByGroup");
            var membersInGroup = restResponse.Convert<List<Member>>();
            foreach (var member in MemberList)
            {
                if (membersInGroup.FirstOrDefault(m => m.Id == member.Id) != null)
                    SelectedMembers = SelectedMembers.Append(member);
            }

        }

        private async Task AssignMembersToGroup()
        {
            var memberInGroup = new MembersInGroup() { GroupId = SelectedGroup.Id, MemberIdList = SelectedMembers.Select(m => m.Id).ToList() };
            _apiConsumer.Body = memberInGroup;
            var restResponse = await _apiConsumer.ExecuteAsync("AssignMembersToGroup");
            MessageResult = "Success";
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
    }
}
