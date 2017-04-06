<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Client_pages_login" %>

<!DOCTYPE html>

<html lang="he" dir="rtl" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />


    <title>תרמתי בבית - התחברות</title>

    <!-- Bootstrap Core CSS -->
    <link href="../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- MetisMenu CSS -->
    <link href="../vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="../dist/css/sb-admin-2.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <%--<!-- our CSS -->
    <link href="../css/formCSS.css" rel="stylesheet" />--%>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->


</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">תרמתי בבית - התחברות</h3>
                        </div>
                        <div class="panel-body">
                            <asp:PlaceHolder ID="serverMSG_PH" runat="server" />
                            <br />
                            <%--<input class="form-control" id="mail_TB" placeholder="אימייל" name="email" type="email"  runat="server"/>--%>
                            <asp:TextBox ID="mail_TB" placeholder="אימייל" runat="server" class="form-control" Text="" />
                            <asp:RegularExpressionValidator ID="mail_TB_Valid" ControlToValidate="mail_TB" runat="server" ErrorMessage="כתובת אימייל לא תקינה" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                            <div class="form-group has-feedback">
                                <asp:TextBox ID="pass_TB" placeholder="סיסמה" TextMode="Password" runat="server" class="form-control" />
                                <span id="pass_Icon" class="glyphicon glyphicon-eye-open form-control-feedback" onclick="toggle()" style="left:0"></span>
                            </div>

                            <div>
                                <asp:CheckBox ID="remember_CB" Text="זכור אותי" runat="server" />
                            </div>
                            <asp:Button ID="login_BTN" Text="התחבר" runat="server" OnClick="login_BTN_Click" class="btn btn-lg btn-success btn-block" />
                            <a href="forgotPass.html">שכחת סיסמה?</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- jQuery -->
    <script src="../vendor/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="../vendor/metisMenu/metisMenu.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="../dist/js/sb-admin-2.js"></script>

    <script>
        var show = false;
        function toggle() {
            if (!show) {
                $("#pass_TB").attr("type", "text");
                $("#pass_Icon").removeClass("glyphicon glyphicon-eye-open");
                $("#pass_Icon").addClass("glyphicon glyphicon-eye-close");
                show = true;
            }
            else {
                $("#pass_TB").attr("type", "password");
                $("#pass_Icon").removeClass("glyphicon glyphicon-eye-close");
                $("#pass_Icon").addClass("glyphicon glyphicon-eye-open");
                show = false;
            }
        }

    </script>


</body>
</html>
