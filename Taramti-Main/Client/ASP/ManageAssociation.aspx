<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageAssociation.aspx.cs" Inherits="Client_ASP_ManageAssociation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:DropDownList ID="showTypeDDL" runat="server" AutoPostBack="true">
            <asp:ListItem Value="%">הכל</asp:ListItem>
            <asp:ListItem Value="admin">admin</asp:ListItem>
            <asp:ListItem Value="advisor">advisor</asp:ListItem>
            <asp:ListItem Value="student">student</asp:ListItem>
        </asp:DropDownList>
        <asp:CheckBox ID="showPermisCB" Text="הצג גם משתמשים לא פעילים" runat="server" AutoPostBack="true" OnCheckedChanged="showPermisCB_CheckedChanged" />
    <div id="GridView1Div">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="association_code" DataSourceID="usersDS" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" Height="223px" Width="665px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="association_code" HeaderText="קוד עמותה" ReadOnly="True" SortExpression="association_code" />
                <asp:BoundField DataField="association_name" HeaderText="שם עמותה" SortExpression="association_name" />
                <asp:BoundField DataField="association_desc" HeaderText="תיאור עמותה" SortExpression="association_desc" />
                <asp:BoundField DataField="account" HeaderText="חשבון" SortExpression="account" />
                <asp:BoundField DataField="website" HeaderText="אתר" SortExpression="website" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </div>
    <%--DeleteCommand="DELETE FROM [Person] WHERE [personId] = @original_personId AND [f_Name] = @original_f_Name AND [l_Name] = @original_l_Name AND [mail] = @original_mail AND [password] = @original_password AND (([image] = @original_image) OR ([image] IS NULL AND @original_image IS NULL)) AND [type] = @original_type AND (([permissionID] = @original_permissionID) OR ([permissionID] IS NULL AND @original_permissionID IS NULL)) AND [teamNum] = @original_teamNum"--%>
    <asp:SqlDataSource ID="usersDS" runat="server" ConnectionString="<%$ ConnectionStrings:ruppinConnectionString %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [association]">

    </asp:SqlDataSource>


    </form>
</body>
</html>
