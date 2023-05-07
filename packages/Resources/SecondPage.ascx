<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SecondPage.ascx.cs" Inherits="DotNetNuke.Modules.FaavanResume1.SecondPage" %>
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
<style type="text/css">
    .style1
    {
        width: 253px;
    }
</style>
<div style="float:right">
<table class="gradienttable" width="25%" >
<caption>
    <strong>ضمینه ی همکاری مورد علاقه ( به ترتیب اولویت علاقه مندی )
</strong>
</caption>
<thead >

<tr >
<td >
   ردیف
   </td>
<td >
    عنوان فعالیت مورد علاقه
</td>
</tr>
</thead>

<tr>
<td width="5%">
    <asp:Label ID="Label3" Text="1" runat="server" />
    <asp:Label ID="radware" Text="*" ForeColor="Red" runat="server" Visible="false" />
</td>
<td>
    <asp:TextBox ID="rad1" runat="server" Width="217px"  />
</td>
</tr>
</table>
<table>
    <tr>
        <td class="style1">
            <asp:ListView ID="lvDynamicTextboxes" runat="server" ItemPlaceholderID="itemPlaceholder" onitemdatabound="lvDynamicTextboxes_ItemDataBound" >
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </LayoutTemplate>
                <ItemTemplate>
                <table class="gradienttable" width="100%">
                <tr>
                <td>
                    <asp:Label ID="lbltest" Text=" #" Width="5%"></td>
                <td>
                <asp:TextBox ID="txtStep" runat="server" Width="95%" />
                </td>
                </tr>
                </table>  
                </ItemTemplate>
            </asp:ListView>

            <table class="gradienttable">
            <tr>
            <td class="style1">
            <asp:LinkButton Text="اضافه کردن به ضمینه های مورد علاقه" ID="good" runat="server" 
                    onclick="good_Click" Font-Underline = "false"  />
            </td>
            </tr>
            </table>
        </td>
    </tr>
</table>
</div>

<div style="float:left;padding-left:30%">

<table class="gradienttable" width="25%" >
<caption>
    <strong> مهارت های خود را اضافه کنید
</strong>
</caption>
<thead >

<tr >
<td >
   ردیف
   </td>
<td >
    عنوان مهارت های شما
</td>
</tr>
</thead>

<tr>
<td width="5%">
    <asp:Label ID="Label1" Text="1" runat="server" />
    <asp:Label ID="Label2" Text="*" ForeColor="Red" runat="server" Visible="false" />
</td>
<td>
    <asp:TextBox ID="onv1" runat="server" Width="217px"  />
</td>
</tr>
</table>

<table>
    <tr>
        <td class="style1">
            <asp:ListView ID="lvdynamictbox" runat="server" ItemPlaceholderID="itemPlaceholder2" onitemdatabound="lvdynamictbox_ItemDataBound" >
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder2" runat="server" />
                </LayoutTemplate>
                <ItemTemplate>
                <table class="gradienttable" width="100%">
                <tr>
                <td>
                    <asp:Label ID="lbltest2" Text=" #" Width="5%"></td>
                <td>
                <asp:TextBox ID="txtstep2" runat="server" Width="95%" />
                </td>
                </tr>
                </table>  
                </ItemTemplate>
            </asp:ListView>

            <table class="gradienttable">
            <tr>
            <td class="style1">
            <asp:LinkButton Text="اضافه کردن به مهارت ها" ID="linkbutton2" runat="server" 
                    onclick="linkbutton2_Click" Font-Underline = "false"  />
            </td>
            </tr>
            </table>
        </td>
    </tr>
</table>
</div>


<br />
<table class="gradienttable" width="70%">
    <caption >
        <strong><br /><br /><span style="font-size:medium"><b>تحصیلات</b></span></strong>
    </caption>
    <thead>
    <tr >
    <td align="center">
        مقطع تحصیلی
    </td>
    <td align="center">
        رشته ی تحصیلی
    </td>
    <td align="center">
        گرایش
    </td>
    <td align="center">
        محل تحصیل
    </td>
    <td align="center">
 سال اخذ
    </td>
    </tr>
    </thead>
    <tr >
    <td>
        <asp:TextBox ID="mth" runat="server" Width="90%" />
    </td>
    <td>
        <asp:TextBox ID="rth" runat="server" Width="90%" />
    </td>
    <td>
        <asp:TextBox ID="grs" runat="server" Width="90%" />
    </td>
    <td>
        <asp:TextBox ID="mtl" runat="server" Width="90%" />
    </td>
    <td>
        <asp:TextBox ID="sala" runat="server" Width="90%" />
    </td>
    </tr>
    <tr >
    <td>
        <asp:TextBox ID="mth2" runat="server" Width="90%" />
    </td>
    <td>
        <asp:TextBox ID="rth2" runat="server" Width="90%" />
    </td>
    <td>
        <asp:TextBox ID="grs2" runat="server" Width="90%" />
    </td>
    <td>
        <asp:TextBox ID="mtl2" runat="server" Width="90%" />
    </td>
    <td>
        <asp:TextBox ID="sala2" runat="server" Width="90%" />
    </td>
    </tr>
    <tr >
    <td>
        <asp:TextBox ID="mth3" runat="server" Width="90%" />
    </td>
    <td>
        <asp:TextBox ID="rth3" runat="server" Width="90%" />
    </td>
    <td>
        <asp:TextBox ID="grs3" runat="server" Width="90%" />
    </td>
    <td>
        <asp:TextBox ID="mtl3" runat="server" Width="90%" />
    </td>
    <td>
        <asp:TextBox ID="sala3" runat="server" Width="90%" />
    </td>
    </tr>
</table>
<div dir="rtl">
<asp:Label ID="lonv" 
        Text="هیچ مهارتی وارد نشده است . وارد کردن حداقل یک مهارت الزامیست" 
        runat="server" ForeColor="Red" Visible="false" />
<br />
<asp:Label ID="lrad" 
        Text="هیچ علاقه مندی ( ضمینه ی همکاری مورد علاقه ای اضافه نشده ، وارد کردن حداقل یک ضمینه ی همکاری الزامیست" 
        runat="server" ForeColor="Red" Visible="false" />
<br />
<asp:Label Text="پر کردن یک سطر از تحصیلات الزامیست" ID="tware" ForeColor="Red" runat="server" Visible="false" />
</div>
<div dir="rtl">
<asp:LinkButton ID="stepproof" Text="<=  تایید و ادامه " runat="server" 
        onclick="stepproof_Click" Font-Bold="True" Font-Size="Small" />
</div>