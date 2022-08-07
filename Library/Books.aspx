<%@ Page Async="true" Language="C#" Title="Books" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Books" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="top-offset-2" >
            <asp:ValidationSummary runat="server" />
        </div>
    </div>
    <div class="row top-offset-2">
        <div class="col-sm-2 col-md-3">
            <asp:FormView runat="server" ID="BookForm"
                ItemType="Library.ViewModels.BookViewModel" 
                InsertMethod="BookForm_InsertItem" DefaultMode="Insert"
                RenderOuterTable="false">
                <InsertItemTemplate>
                    <fieldset>   
                        <asp:DynamicEntity runat="server" Mode="Insert" />
                        <div class="col-sm-4 col-md-10 top-offset-2">
                             <asp:Button runat="server" Text="Insert" CommandName="Insert" />
                             <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="Cancel_Click" />
                        </div>
                    </fieldset>
                </InsertItemTemplate>
            </asp:FormView>
        </div>
        <div class="col-sm-4 col-md-7">
            <asp:GridView ID="BookList" runat="server" 
                ItemType="Library.ViewModels.BookViewModel" 
                DeleteMethod="BookList_DeleteItem" 
                SelectMethod="BookList_GetData"
                UpdateMethod="BookList_UpdateItem"
                CssClass="mydatagrid" 
                PagerStyle-CssClass="pager" 
                HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" >
                <Columns>
                    <asp:CommandField CausesValidation="false" ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name"/>
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="PublishingDate" HeaderText="PublishingDate" DataFormatString="{0:dd/MM/yyyy}"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>