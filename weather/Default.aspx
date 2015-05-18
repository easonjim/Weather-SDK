<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="weather.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    中国天气API<br />
    经纬度<br />
    经度：<asp:TextBox ID="txt_Latitude" runat="server"></asp:TextBox><br />
    纬度：<asp:TextBox ID="txt_Longitude" runat="server"></asp:TextBox><br />
    类型：<asp:DropDownList ID="ddl_MethodType1" runat="server">
           <asp:ListItem Selected="True" Text="Data" Value="data"></asp:ListItem>
           <asp:ListItem Text="SK" Value="sk"></asp:ListItem>
           <asp:ListItem Text="CityInfo" Value="cityinfo"></asp:ListItem>
          </asp:DropDownList>
          <br />
    <asp:Button ID="Button1" runat="server" Text="调用" OnClick="Button1_Click" /><br /><br />
    
    城市<br />
    城市：<asp:TextBox ID="txt_City" runat="server"></asp:TextBox><br />
    类型：<asp:DropDownList ID="ddl_MethodType2" runat="server">
           <asp:ListItem Selected="True" Text="Data" Value="data"></asp:ListItem>
           <asp:ListItem Text="SK" Value="sk"></asp:ListItem>
           <asp:ListItem Text="CityInfo" Value="cityinfo"></asp:ListItem>
          </asp:DropDownList>
          <br />
    <asp:Button ID="Button2" runat="server" Text="调用" OnClick="Button2_Click" /><br />
    <asp:Button ID="Button4" runat="server" Text="通过城市名获取城市代码" OnClick="Button4_Click" /><br /><br />
    
    代码<br />
    代码：<asp:TextBox ID="txt_ID" runat="server"></asp:TextBox><br />
    类型：<asp:DropDownList ID="ddl_MethodType3" runat="server">
           <asp:ListItem Selected="True" Text="Data" Value="data"></asp:ListItem>
           <asp:ListItem Text="SK" Value="sk"></asp:ListItem>
           <asp:ListItem Text="CityInfo" Value="cityinfo"></asp:ListItem>
          </asp:DropDownList>
          <br />
    <asp:Button ID="Button3" runat="server" Text="调用" OnClick="Button3_Click" /><br />
    <asp:Button ID="Button5" runat="server" Text="通过代码获取城市名" OnClick="Button5_Click" /><br /><br />
    
    手机网页<br />
    代码：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    类型：<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_OnSelectedIndexChanged">
           <asp:ListItem Selected="True" Text="全国雷达" Value="1"></asp:ListItem>
           <asp:ListItem Text="全国气象公报" Value="2"></asp:ListItem>
           <asp:ListItem Text="实时天气详情" Value="3"></asp:ListItem>
           <asp:ListItem Text="网页雷达" Value="4"></asp:ListItem>
           <asp:ListItem Text="卫星云图" Value="5"></asp:ListItem>
           <asp:ListItem Text="温度实况" Value="6"></asp:ListItem>
           <asp:ListItem Text="风速实况" Value="7"></asp:ListItem>
           <asp:ListItem Text="灾难预警" Value="8"></asp:ListItem>
           <asp:ListItem Text="城市雷达" Value="9"></asp:ListItem>
           <asp:ListItem Text="城市趋势" Value="10"></asp:ListItem>
           <asp:ListItem Text="城市指数" Value="11"></asp:ListItem>
           <asp:ListItem Text="降雨量" Value="12"></asp:ListItem>
          </asp:DropDownList>
          <br />
    是否需要参数：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
    URL：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
    <asp:Button ID="Button6" runat="server" Text="调用" OnClick="Button6_Click" /><br /><br />
    </div>
    </form>
</body>
</html>
