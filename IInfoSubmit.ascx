<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IInfoSubmit.ascx.cs" Inherits="DotNetNuke.Modules.FaavanResume1.IInfoSubmit" %>
<script type="text/javascript" language="javascript">
    window.onload = function () {
        noBack();
    }
    function noBack() {
        window.history.forward();
    }
</script>
<body  onpageshow="if (event.persisted) noBack();">
</body>
<div style="text-align:center">
        <asp:Label Text="زومه ی شما در سیستم ثبت شد . در صورت وجود فضای همکاری برای مهارت های شما . تا چند روز دیگر از طریق همین صفحه و با وارد کردن ایمیل در صفحه ی اصلی نتیجه را مشاهده کنید" 
            ID="infor" runat="server" Font-Bold="True" />
            <br />
            <asp:Label ID="natije" runat="server" BackColor="White" BorderColor="Green" 
            BorderStyle="Solid" Font-Bold="True" ForeColor="Black" />
</div>




<p dir="rtl">
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
        <PagerStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:GridView>
    <br />
    <asp:GridView ID="grid3" runat="server" PageSize="1" Width="100%" 
        CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
        GridLines="None" HorizontalAlign="Center" 
        onpageindexchanging="grid3_PageIndexChanging" Caption="علایق و ضمینه های همکاری" 
        CaptionAlign="Top">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:GridView>
    <br />
    <asp:GridView ID="maharat" runat="server" PageSize="1" CellPadding="4" Width="100%"
        EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
        Caption="مهارت و توانایی ها" CaptionAlign="Top" 
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
    
</p>
<div style="text-align:center">
<asp:Label ID="not" Text="رزومه ی شما ثبت شده ، برای مشاهده ی نتیجه بعدا از طریق تایپ ایمیل و ورود در صفحه ی اصلی اقدام کنید" runat="server" />
<br />
    <asp:Button Text="بازگشت به صفحه ی اصلی" ID="back" runat="server" 
        onclick="back_Click" Font-Bold="True" Font-Size="Small" Width="161px" />
        <br />
</div>

