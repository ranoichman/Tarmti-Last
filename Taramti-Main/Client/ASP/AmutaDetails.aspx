<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AmutaDetails.aspx.cs" Inherits="Client_ASP_AmutaDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">--%>
    <div class="PlaceHolderDiv">
        <div id="Header">פרטי הפרויקט </div>
        <table id="tbl" runat="server">

            <tr>
                <td>שם העמותה:</td>
                <td>
                    <asp:TextBox ID="pName_TB" runat="server" data-name="שם עמותה: "></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ControlToValidate="pName_TB" ID="pName_TB_ValidRQ" runat="server" ErrorMessage="שדה חובה!"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ControlToValidate="pName_TB" ID="pName_TB_ValidCR" runat="server" ClientValidationFunction="Valid_Min2Char" ErrorMessage="שדה זה חייב להכיל לפחות 2 תווים"></asp:CustomValidator>
                </td>
            </tr>

            <tr>
                <td>סוג הפרויקט:</td>
                <td>
                    <asp:DropDownList ID="pType_DDL" runat="server" data-name="סוג הפרויקט: " DataSourceID="SqlDataSource1"  AppendDataBoundItems="true" DataTextField="type" DataValueField="projTypeID">
                        <asp:ListItem Value="בחר">בחר</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjDetailsConnectionString %>" 
                        DeleteCommand="DELETE FROM [projType] WHERE [projTypeID] = @projTypeID" 
                        InsertCommand="INSERT INTO [projType] ([type]) VALUES (@type)" 
                        SelectCommand="SELECT * FROM [projType]" 
                        UpdateCommand="UPDATE [projType] SET [type] = @type WHERE [projTypeID] = @projTypeID" OnSelecting="SqlDataSource1_Selecting">
                        <DeleteParameters>
                            <asp:Parameter Name="projTypeID" Type="Int16" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="type" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="type" Type="String" />
                            <asp:Parameter Name="projTypeID" Type="Int16" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="pType_DDLValidRq" InitialValue="בחר" ControlToValidate="pType_DDL" runat="server" ErrorMessage="לא ניתן לבחור באופציה זו" />
                </td>
            </tr>

            <tr>
                <td>לוגו הפרויקט:</td>
                <td>
                    <asp:FileUpload ID="LogoFUp" runat="server" BorderStyle="Inset" data-name="לוגו הפרויקט: " />
                </td>
                <td>
                    <asp:RequiredFieldValidator ControlToValidate="LogoFUp" ID="LogoFUp_ValidRq" runat="server" ErrorMessage="שדה חובה!"></asp:RequiredFieldValidator>
                    <%--<asp:CustomValidator ID="LogoFUp_ValidCr" runat="server" ControlToValidate="LogoFUp" ErrorMessage="יחס התמונה אינו 4:3" OnServerValidate="ValidRatio_ServerValidate"></asp:CustomValidator>--%>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Tag1LBL" runat="server" data-name="תגית 1: ">תגית 1:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Tag1TB" runat="server" onkeyup="changeStatus(this,'#ContentPlaceHolder1_Tag2TB')" data-name="תיאור התגית: "></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="Tag1TB_ValidRq" ControlToValidate="Tag1TB" runat="server" ErrorMessage="שדה חובה!"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td >
                    <asp:Label ID="Tag2LBL" runat="server" data-name="תגית 2: ">תגית 2:</asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="Tag2TB" runat="server" data-name="תיאור התגית: " Enabled="False" onblur="insRow(this,'#ContentPlaceHolder1_Tag2TB')" ></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>לינק לסרטון הפרויקט:</td>
                <td>
                    <asp:TextBox ID="VidLinkTB" runat="server" data-name="סרטון הפרויקט: "></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="VidLinkTB_ValidRQ" ControlToValidate="VidLinkTB" runat="server" ErrorMessage="שדה חובה"></asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="VidLinkTB_ValidLink" ControlToValidate="VidLinkTB" runat="server" ValidationExpression="^(?:https?\:\/\/)?(?:www\.)?(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\/|watch\?v\=))([\w-]{10,12})(?:$|\&|\?\#).*" ErrorMessage ="לינק לא תקין"></asp:RegularExpressionValidator>

                </td>
            </tr>

            <tr>
                <td>
                    <p id="P_Project_D">תיאור הפרויקט:</p>
                </td>
                <td class="auto-style1">
                    <textarea id="pDesc_TA" cols="40" rows="10" runat="server" dir="rtl" data-name="תיאור הפרויקט: "></textarea>
                </td>
                <td>
                    <asp:RequiredFieldValidator ControlToValidate="pDesc_TA" ID="pDesc_TA_ValidRq" runat="server" ErrorMessage="שדה חובה!"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ControlToValidate="pDesc_TA" ID="pDesc_TA_VaildCR" runat="server" ClientValidationFunction="Valid_Min2Char" ErrorMessage="שדה זה חייב להכיל לפחות 2 תווים"></asp:CustomValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:TextBox ID="TargetTB" runat="server" onkeyup="changeStatus(this,'#ContentPlaceHolder1_Target1TB')" placeholder="תיאור מטרה:" data-name="תיאור מטרה: " />
                </td>
                <td>
                    <asp:TextBox ID="StaTargetTB" runat="server" onkeyup="changeStatus(this,'#ContentPlaceHolder1_StaTarget1TB')" placeholder="סטטוס" data-name="סטטוס: " />
                </td>
                <td>
                    <asp:RequiredFieldValidator ControlToValidate="TargetTB" ID="TargetTB_ValidRq" runat="server" ErrorMessage="שדה חובה!"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ControlToValidate="StaTargetTB" ID="StaTargetTB_ValidRq" runat="server" ErrorMessage="שדה חובה!"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ControlToValidate="StaTargetTB" ID="StaTargetTB_ValidCr" runat="server" ClientValidationFunction="Valid_Min2Char" ErrorMessage="שדה זה חייב להכיל לפחות 2 תווים"></asp:CustomValidator>
                    <asp:CustomValidator ControlToValidate="TargetTB" ID="TargetTB_ValidCr" runat="server" ClientValidationFunction="Valid_Min2Char" ErrorMessage="שדה זה חייב להכיל לפחות 2 תווים"></asp:CustomValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:TextBox ID="Target1TB" runat="server" placeholder="תיאור מטרה:" data-name="תיאור מטרה: " Enabled="False" />
                </td>
                <td>
                    <asp:TextBox ID="StaTarget1TB" runat="server" placeholder="סטטוס" data-name="סטטוס: " Enabled="False" />
                </td>
                <td>
                    <asp:CustomValidator ControlToValidate="StaTarget1TB" ID="StaTarget1TB_ValidCr" runat="server" ClientValidationFunction="Valid_Min2Char" ErrorMessage="שדה זה חייב להכיל לפחות 2 תווים"></asp:CustomValidator>
                    <asp:CustomValidator ControlToValidate="Target1TB" ID="Target1TB_ValidCr" runat="server" ClientValidationFunction="Valid_Min2Char" ErrorMessage="שדה זה חייב להכיל לפחות 2 תווים"></asp:CustomValidator>
                </td>
            </tr>

            <tr>
                <td>מנחה חלק א':</td>
                <td>
                    <asp:DropDownList ID="mSemA_DDL" runat="server" data-name="מנחה חלק א: " DataSourceID="SqlDataSourceTeachers" AppendDataBoundItems="true" DataTextField="Name" DataValueField="personId">
                        <asp:ListItem Value="בחר">בחר</asp:ListItem>
<%--                        <asp:ListItem>דיצה ביימל</asp:ListItem>
                        <asp:ListItem>עמית רכבי</asp:ListItem>
                        <asp:ListItem>אריה עמית</asp:ListItem>
                        <asp:ListItem>ערבה צורי</asp:ListItem>
                        <asp:ListItem>דוד בנימין</asp:ListItem>--%>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceTeachers" runat="server" ConnectionString="<%$ ConnectionStrings:ruppinProjDBConnectionString %>" 
                        SelectCommand="SELECT ([f_Name] + ' ' +  [l_Name]) as Name,personId FROM [Person] where type = 'advisor' and  [is_sem_a] = 1"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="mSemA_DDL_Valid_Rq" InitialValue="בחר" ControlToValidate="mSemA_DDL" runat="server" ErrorMessage="לא ניתן לבחור באופציה זו" />
                </td>
            </tr>

            <tr>
                <td>מנחה חלק ב':</td>
                <td>
                    <asp:DropDownList ID="mSemB_DDL" runat="server" data-name="מנחה חלק ב: " DataSourceID="SqlDataSourceTeacher2"  AppendDataBoundItems="True" DataTextField="Name" DataValueField="personId">
                        <asp:ListItem Value="בחר">בחר</asp:ListItem>
                  <%--      <asp:ListItem>בני בורנפלד</asp:ListItem>
                        <asp:ListItem>ניר חן</asp:ListItem>--%>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceTeacher2" runat="server" ConnectionString="<%$ ConnectionStrings:ruppinProjDBConnectionString %>"
                         SelectCommand="SELECT ([f_Name] + ' ' +  [l_Name]) as Name, personId FROM [Person] where type = 'advisor' and [is_sem_a] = 0"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="mSemB_DDL_Valid_Rq" InitialValue="בחר" ControlToValidate="mSemB_DDL" runat="server" ErrorMessage="לא ניתן לבחור באופציה זו" />
                </td>
            </tr>

            <tr>
                <td>אתגרי המערכת:</td>
                <td>
                    <asp:TextBox ID="ChallengeTb" runat="server" data-name="אתגרי המערכת: "></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>הערות:</td>
                <td>
                    <textarea id="comments_TA" cols="100" rows="2" runat="server" dir="rtl" data-name="הערות: "></textarea>
                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button ID="SaveBtn" Text="שמור" runat="server" OnClick="SaveBtn_Click" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
    </div>
    </form>
</body>
</html>
