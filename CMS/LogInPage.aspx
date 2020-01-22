<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInPage.aspx.cs" Inherits="ComManSys.LogInPage" %>

<!DOCTYPE html>

<!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

<!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

<!-- Latest compiled JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
        img {
        max-width: 100%;
        height: auto;
        display: block;
        margin: 0 auto;
        }
        </style>
</head>
<body>
   <%-- <form id="form1" runat="server">--%>

<div class="container">   
        <img src="https://i.imgur.com/lCCoXKF.png" alt="logo" width="500" height="150" vertical-align: text-top>
        <div id="loginbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">                    
            <div class="panel panel-info" >
                    <div class="panel-heading">
                        <div class="panel-title">Sign In</div>
                        <%--<div style="float:right; font-size: 80%; position: relative; top:-10px"><a href="#">Forgot password?</a></div>--%>
                    </div>     

                    <div style="padding-top:30px" class="panel-body" >

                        <div style="display:none" id="login-alert" class="alert alert-danger col-sm-12"></div>
                            
                        <form id="loginform" class="form-horizontal" role="form" runat="server">
                                    
                            <div style="margin-bottom: 25px" class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                        <%--<input id="login-username" type="text" class="form-control" name="username" value="" placeholder="username or email">--%>
                                        <asp:textbox class="form-control" id="txtuser" placeholder="Username or Email" runat="server"></asp:textbox>
                                    </div>
                                
                            <div style="margin-bottom: 25px" class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                        <%--<input id="login-password" type="password" class="form-control" name="password" placeholder="password">--%>
                                        <asp:textbox class="form-control" id="txtpwd" placeholder="password" runat="server" textmode="Password"></asp:textbox>
                                    </div>
                                    

                                
                           <%-- <div class="input-group">
                                      <div class="checkbox">
                                        <label>
                                          <input id="login-remember" type="checkbox" name="remember" value="1"> Remember me
                                        </label>
                                      </div>
                                    </div>--%>


                                <div style="margin-top:10px" class="form-group">
                                    <!-- Button -->

                                    <div class="col-sm-12 controls">
                                      <%--<a id="btn-login" href="#" class="btn btn-success" onclick="ValidateUser">Login  </a>--%>
                                      <asp:button cssclass="btn btn-success" id="btnLogin" onclick="ValidateUser" runat="server" text="Login"></asp:button>                          
                                      
                                        <br />
                                        <br />
                                      
                                      <asp:label cssclass="label label-danger" id="lblmsg" runat="server"></asp:label>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="col-md-12 control">
                                        <div style="border-top: 1px solid#888; padding-top:15px; font-size:85%" >
                                            Don't have an account?
                                        <%--<a href="#" onClick="$('#loginbox').hide(); $('#signupbox').show()">--%>
                                            <%--Sign Up Here
                                        </a>--%>
                                        <asp:Button ID="SignUpBtn" runat="server" OnClick="SignUpButton_Click" Text="Sign up Here!" />
                                        </div>
                                    </div>
                                </div>    
                            </form>     
                        </div>                     
                    </div>  
        </div>
    </div>
   </body>
</html> 