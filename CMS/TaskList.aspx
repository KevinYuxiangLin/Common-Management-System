<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskList.aspx.cs" Inherits="CMS.TaskList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <%-- <div class="style1">
    </div>--%>
    <div>
        <asp:GridView ID="gvTaskList" runat="server" AutoGenerateColumns="False" CssClass="Grid" BorderWidth="0" GridLines="None"
            OnRowCancelingEdit="gvTaskList_RowCancelingEdit"
            OnRowDeleting="gvTaskList_RowDeleting"
            OnRowEditing="gvTaskList_RowEditing" OnRowUpdating="gvTaskList_RowUpdating"
            DataKeyNames="TaskListId"
            OnRowCommand="gvTaskList_RowCommand" Font-Size="Small">
            <Columns>
                <asp:CommandField ShowEditButton="true" ControlStyle-Font-Underline="true" ControlStyle-ForeColor="Blue" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="deleteListButton" runat="server" Font-Underline="true" ForeColor="Blue" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure to delete this record?');" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="List Id">
                    <ItemTemplate>
                        <asp:Label ID="LabelListId" runat="server" Text='<%# Eval("TaskListId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="List Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TaskListName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("TaskListName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Task Detail">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" Text="Open Task" CommandName='<%# Eval("TaskListId") %>' CommandArgument='<%#Container.DataItemIndex%>' />
                        <asp:GridView ID="gvTasks" AutoGenerateColumns="false" runat="server" BorderWidth="0" GridLines="None"
                            DataKeyNames="TaskId" CssClass="ChildGrid"
                            OnRowCancelingEdit="gvTasks_RowCancelingEdit"
                            OnRowDeleting="gvTasks_RowDeleting"
                            OnRowEditing="gvTasks_RowEditing" OnRowUpdating="gvTasks_RowUpdating" Font-Size="Small">
                            <Columns>
                                <asp:CommandField ButtonType="Link" ShowEditButton="true" ControlStyle-Font-Underline="true" ControlStyle-ForeColor="Blue" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="deleteTaskButton" runat="server" Font-Underline="true" ForeColor="Blue" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure to delete this record?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Task Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("TaskName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval("TaskName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Priority">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("PriorityName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval("PriorityName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Due Date">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("DueDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval("DueDate") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Progress">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelProgress" runat="server" Text='<%# Eval("Progress") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

