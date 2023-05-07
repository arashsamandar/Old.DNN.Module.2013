<%@ Control language="C#" Inherits="DotNetNuke.Modules.FaavanResume1.Edit" AutoEventWireup="false"  Codebehind="Edit.ascx.cs" %>
<div style="text-align:center">
<asp:DropDownList  ID="ddl" runat="server" 
    CausesValidation="True"  DataValueField="pid" 
    onselectedindexchanged="ddl_SelectedIndexChanged" 
    ontextchanged="ddl_SelectedIndexChanged" AutoPostBack="True" BackColor="Gray" 
        Font-Size="Medium" ForeColor="White" />

<br /><br />
</div>
<div style="padding-right:50%;padding-left:42%">
<asp:Image ID="imgPreview" runat="server" 
    BorderStyle="None" Height="214px" Width="170px" />
    </div>
    <div dir="rtl">
    <asp:Label ID="number" runat="server" />
    <br />
    <asp:Label ID="tozihat" runat="server" />
    <br />
    <asp:TextBox Width="562px" ID="natijeh" runat="server" />
    <asp:Button Text="ارسال نتیجه" ID="nnatijeh" runat="server" Width="75px" 
            Height="22px" onclick="nnatijeh_Click" />
    </div>
<div dir="rtl">
    <asp:GridView ID="GridView1" runat="server" PageSize="1" Width="100%"
        CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
        GridLines="None" onpageindexchanging="GridView1_PageIndexChanging" 
        HorizontalAlign="Center" Caption="مشخصات فردی" CaptionAlign="Top">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:GridView>
    <br />
    <asp:GridView ID="grid2" runat="server" Pagesize="1" Width="100%"
        CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
        GridLines="None" HorizontalAlign="Center" Caption="میزان تحصیلات" 
        CaptionAlign="Top">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:GridView>
    <br />
    <asp:GridView ID="grid3" runat="server" PageSize="1" Width="100%" 
        CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
        GridLines="None" HorizontalAlign="Center" 
        onpageindexchanging="grid3_PageIndexChanging" Caption="ضمینه ی همکاری مورد علاقه" 
        CaptionAlign="Top">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#333333" HorizontalAlign="Center" BackColor="#FFCC66" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:GridView>
    <br />
    <asp:GridView ID="maharat" runat="server" PageSize="1" CellPadding="4" Width="100%"
        EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
        Caption="مهارت ها و توانایی ها" CaptionAlign="Top" 
        HorizontalAlign="Center" >
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:GridView>
    <br />
    <asp:GridView ID="savabeghkari" runat="server" PageSize="1" CellPadding="4" Width="100%"
        EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
        Caption="سوابق کاری" CaptionAlign="Top" 
        HorizontalAlign="Center">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:GridView>
    <br />
    <div style="text-align:center" >
    <asp:Label Text="توضیحات اضافه" runat="server" />
    <br />
    <asp:TextBox ID="tozihhat" TextMode="MultiLine" BorderStyle="Inset" runat="server" />
    </div>
</div>

