using RestSharp;
using Telerik.Blazor.Components;
using Zion1.Common.API.Consumer;
using Zion1.Membership.Web.UI.Models;

namespace Zion1.Membership.Web.UI.Components
{
    public partial class ManageGroup
    {
        public List<Group> GroupList { get; set; } = new List<Group>();
        public string MessageResult { get; set; } = string.Empty;
        public TelerikNotification NotificationResult { get; set; } = new();

        private ApiConsumer _apiConsumer = new ApiConsumer(ApiHelper.GetApiSettings());

        public ManageGroup()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            await GetGroupList();
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

        private async Task GetGroupList()
        {
            var restResponse = await _apiConsumer.ExecuteAsync("GetGroupList");
            GroupList = restResponse.Convert<List<Group>>();
        }

        private async Task CreateGroup(GridCommandEventArgs args)
        {
            Group? groupInfo = args.Item as Group;

            if (groupInfo != null)
            {

                _apiConsumer.Body = groupInfo;
                var response = await _apiConsumer.ExecuteAsync("CreateGroup");

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
                MessageResult = "Group info is null";
            }

            //Reload Data
            await GetGroupList();
        }

        private async Task UpdateGroup(GridCommandEventArgs args)
        {
            Group? groupInfo = args.Item as Group;

            if (groupInfo != null)
            {
                _apiConsumer.Body = groupInfo;
                var response = await _apiConsumer.ExecuteAsync("UpdateGroup");

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
                MessageResult = "Group info is null";
            }

            //Reload Data
            await GetGroupList();
        }

        private async Task DeleteGroup(GridCommandEventArgs args)
        {
            Group? groupInfo = args.Item as Group;

            if (groupInfo != null)
            {

                _apiConsumer.Params.Add("id", groupInfo.Id.ToString());
                var response = await _apiConsumer.ExecuteAsync("DeleteGroup");

                

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
                MessageResult = "Group info is null";
            }

            //Reload Data
            await GetGroupList();
        }


        private Group SelectedGroup { get; set; } = new();
        private bool IsOpenAssignMember { get; set; } = false;
        private void OpenAssignMember(GridCommandEventArgs args)
        {
            SelectedGroup = args.Item as Group ?? new();
            IsOpenAssignMember = true;
        }
        
    }
}
