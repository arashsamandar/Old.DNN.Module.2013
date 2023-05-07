<%@ Control language="C#" Inherits="DotNetNuke.Modules.FaavanResume1.View" AutoEventWireup="false"  Codebehind="View.ascx.cs" %>
<link href="module.css" rel="Stylesheet" type="text/css" />

<style type="text/css">
    .style1
    {
        padding-left: 5px;
        padding-right: 5px;
        margin-left: 5px;
        margin-right: 5px;
        width: 44px;
    }
</style>




<div dir="rtl">
<table class="gradienttable" width="30%">
<caption>
<span>جهت اطلاع از وضعیت رزومه ی خود لاگین کنید</span><br />&nbsp

</caption>
<tr>
<td class="style1">
<asp:Label Text="ایمیل" ID="lblogin" runat="server" Font-Size="Small" />
<asp:Label Text="*" ID="invalidemail" ForeColor="Red" Font-Size="Small" Visible="false" runat="server" />
</td>
<td class="cellpading">
<asp:TextBox ID="ueamil" runat="server" Width="196px" />
</td>
</tr>
</table>
<br />
&nbsp;
<asp:LinkButton ID="LinkButton1" Text="ورود" runat="server" 
        onclick="Unnamed1_Click" />
&nbsp&nbsp&nbsp&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:LinkButton ID="LinkButton2" Text="ثبت نام" runat="server" 
        onclick="LinkButton2_Click" />
        <br />
<asp:Label ID="invalidemail2" Visible="false" ForeColor="Red" Text="فرمت ایمیل صحیح نیست ، لطفا یک ایمیل معتبر وارد کنید" Font-Size="Small" runat="server" />
<br />
<asp:Label ID="checkusername" runat="server" BackColor="Azure" ForeColor="Red" />
</div>
<asp:Label ID="showstringcon" runat="server" />

