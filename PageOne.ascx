<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageOne.ascx.cs" Inherits="DotNetNuke.Modules.FaavanResume1.LoginSignIn" %>
<style type="text/css">
    .style2
    {
        width: 73px;
    }
</style>
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
<link href="module.css" rel="Stylesheet" type="text/css" />


<div dir="rtl">



<asp:FileUpload runat="server" ID="picup" />
<br />
<asp:Button runat="server" ID="bpictup" Text="ارسال تصویر" 
        onclick="bpictup_Click" />
<br />
<asp:Label runat="server" ID="lpicup" 
        Text = "برای انتخاب عکس ابتدا روی دکمه ی  Browse کلیک کنید<br />اندازه ستونی و ترجیحا 170 در 214 . عکس پرسنلی الزامی نیست" 
        Font-Overline="False" Font-Size="Small" Font-Underline="True" 
        ForeColor="Red"  />
<br />
</div>


<div dir="rtl">
<table frame="box">
<tr>
<td>
<asp:Image ID="imgPreview" runat="server" BorderColor="Black" 
    BorderStyle="Solid" Height="214" ImageAlign="Middle" Width="170" Visible="false" 
/>
</td>
</tr>
</table>
</div>

<table class="gradienttable" width="70%">
    <caption>
        <strong>مشخصات و رزومه را با دقت وارد کنید</strong></caption>
    <tr >
    <td>
        <asp:Label ID="Label2" Text="نام" runat="server"/>
    </td>
    <td style="margin-right: 40px">
        <asp:TextBox  ID="nms" runat="server" />
    </td>
    <td>
        <asp:Label ID="Label3" Text="نام خانوادگی" runat="server" />
    </td>
    <td>
        <asp:TextBox ID="fml" runat="server" />
        
    </td>
    </tr>

    <tr >
    
    <td>
         <asp:Label ID="Label4" Text="نام پدر" runat="server" />
         
    </td>

    <td>
        <asp:TextBox ID="fname" runat="server" />
    </td>
    <td>
    
        <asp:Label ID="Label5" Text="سال تولد" runat="server" />
        
    </td>
    <td>
        <asp:TextBox ID="bday" runat="server" />
    </td>
    </tr>

    <tr >
        <td>
        <asp:Label ID="Label6" Text="شماره شناسنامه" runat="server" />
        
        </td>

        <td>
            <asp:TextBox ID="iid" runat="server" />
        </td>

        <td>
            <asp:Label ID="Label7" Text="محل صدور" runat="server" />
        </td>
        <td>
            <asp:TextBox ID="ms" runat="server" />
        </td>
    </tr>
    <tr >
    <td>
        <asp:Label ID="nvl" Text="نظام وظیفه" runat="server"  />

    </td>
    <td>
        <asp:DropDownList ID="nv" runat="server" 
            onselectedindexchanged="nv_SelectedIndexChanged" Height="22px" 
            Width="132px">
        <asp:ListItem Value="1" Text="خانم" Selected="True" />
        <asp:ListItem Value="2" Text="معاف از خدمت کفالت" />
        <asp:ListItem Value="3" Text="معاف از خدمت دانشجویی" />
        <asp:ListItem Value="4" Text="معاف از خدمت - سایر موارد" />
        <asp:ListItem Value="5" Text="سایر موارد و یا مشمول" />
        </asp:DropDownList>
    </td>
    </tr>
</table>



<table class="gradienttable" width="70%">
<tr>
<td class="style2">
<asp:Label Text="شماره تلفن" ID="lshotele" runat="server" />
</td>
<td>
<asp:TextBox ID="shotele" runat="server" Width="98%" />
</td>
</tr>
<tr>
<td class="style2">
<asp:Label Text="*" runat="server" ID="emailscontrol" Visible="false" ForeColor="Red" />
<asp:Label Text="ایمیل" runat="server" />
<td>
<asp:TextBox ID="emails" runat="server" Width="98%" />
</td>
</tr>
<tr>
<td class="style2">
<asp:Label runat="server" Text="آدرس" Width="5%" />
</td>
<td>
<asp:TextBox runat="server" ID="address" Width="98%" />
</td>
</tr>
</table>
<div dir="rtl">
    <asp:Label  ID="emailsbuttom" Text="فرمت ایمیل صحیح نیست ،  نمونه ی صحیح : example@yahoo.com" Font-Size="Medium" ForeColor="Red" Visible="false" runat="server" />
    <br />
    <asp:Label Text="وارد کردن همه ی موارد ، بجز شماره شناسنامه آن هم در صورتی که تبعه ی کشور ایران نیستید الزامی است"  ForeColor="Red" runat="server" ID="warecontrol" Visible="false" />
</div>
<div dir="rtl" >
<asp:LinkButton Text="<=  تایید و ادامه " ID="btget" runat="server" 
        onclick="btget_Click" />
</div>