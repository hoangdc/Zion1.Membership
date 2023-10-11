using Telerik.Blazor.Components;
using Zion1.Common.API.Consumer;
using Zion1.Membership.Web.UI.Models;

namespace Zion1.Membership.Web.UI.Components
{
    public partial class ManageMember
    {
        public List<Member> MemberList { get; set; } = new List<Member>();
        public string MessageResult { get; set; } = string.Empty;
        public TelerikNotification NotificationResult { get; set; } = new();

        private ApiConsumer _apiConsumer = new ApiConsumer(ApiHelper.GetApiSettings());

        public List<Group> GroupList { get; set; } = new();
        public int SelectedGroupId { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            await GetMemberList();
            await GetGroupList();
        }

        private async Task GetMemberList()
        {
            if (SelectedGroupId == 0)
            {
                var restResponse = await _apiConsumer.ExecuteAsync("GetMemberList");
                MemberList = restResponse.Convert<List<Member>>();
            }
            else
            {
                _apiConsumer.Params.Add("groupid", SelectedGroupId.ToString());
                var restResponse = await _apiConsumer.ExecuteAsync("GetMemberListByGroup");
                MemberList = restResponse.Convert<List<Member>>();
            }
        }

        private async Task Group_OnChange()
        {
            await GetMemberList();
        }

        private async Task GetGroupList()
        {
            var restResponse = await _apiConsumer.ExecuteAsync("GetGroupList");
            GroupList = restResponse.Convert<List<Group>>();
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

                _apiConsumer.Params.Add("id", memberInfo.Id.ToString());
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
            }

            return base.OnAfterRenderAsync(firstRender);
        }
    }
}
