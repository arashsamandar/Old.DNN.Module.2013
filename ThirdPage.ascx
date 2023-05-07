<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThirdPage.ascx.cs" Inherits="DotNetNuke.Modules.FaavanResume1.ThirdPage" %>
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
<table width="100%" class="gradienttable">
<caption >
    <strong>سوابق کاری</strong></caption>
<thead >
<td width="5%">
    <strong>ردیف</strong>
</td>
<td align="center">
    <strong>شغل</strong>
</td>
<td align="center">
    <strong>شروع</strong>
</td>
<td align="center">
    <strong>پایان</strong>
</td>
<td align="center">
    <strong>محل</strong>
</td>
<td align="center">
    <strong>علت پایان همکاری</strong>
</td>
</thead>
<tr >
    <td align="center">
        1
    </td>
    <td>
        <asp:TextBox ID="shoghl1" runat="server" Width="95%"  />
    </td>
    <td>
        <asp:TextBox ID="shoro1" runat="server" Width="95%"  />
    </td>
    <td>
        <asp:TextBox ID="payan1" runat="server" Width="95%"  />
    </td>
    <td>
        <asp:TextBox ID="mahal1" runat="server" Width="95%"  />
    </td>
    <td>
        <asp:TextBox ID="elat1" runat="server" Width="95%"  />
    </td>
</tr>
<tr >
    <td align="center">
        2
    </td>
    <td>
        <asp:TextBox ID="shoghl2" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="shoro2" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="payan2" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="mahal2" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="elat2" runat="server" Width="95%" />
    </td>
</tr>
<tr >
    <td align="center">
        3
    </td>
    <td>
        <asp:TextBox ID="shoghl3" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="shoro3" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="payan3" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="mahal3" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="elat3" runat="server" Width="95%" />
    </td>
</tr>
<tr >
    <td align="center">
        4
    </td>
    <td>
        <asp:TextBox ID="shoghl4" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="shoro4" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="payan4" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="mahal4" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="elat4" runat="server" Width="95%" />
    </td>
</tr>
<tr >
    <td align="center">
        5
    </td>
    <td>
        <asp:TextBox ID="shoghl5" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="shoro5" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="payan5" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="mahal5" runat="server" Width="95%" />
    </td>
    <td>
        <asp:TextBox ID="elat5" runat="server" Width="95%" />
    </td>
</tr>
</table>
    <br />
</div>
<div>
<asp:TextBox TextMode="MultiLine" ID="tozihattt" BorderStyle="Inset" Width="50%" 
        Rows="5" runat="server" 
        Text="در صورتی که توضیحات اضافه ای دارید . در این قسمت وارد کنید" />
</div>
<div dir="rtl">
    <asp:LinkButton ID="thproof" runat="server" Text="<= تایید و ادامه" 
        onclick="thproof_Click" Font-Bold="True" />
</div>