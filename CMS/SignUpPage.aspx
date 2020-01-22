<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpPage.aspx.cs" Inherits="ComManSys.SignUpPage" %>

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
        <div id="signupbox" style="margin-top:50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="panel-title">Sign Up</div>
                            <%--<div style="float:right; font-size: 85%; position: relative; top:-10px"><a id="signinlink" href="#" onclick="$('#signupbox').hide(); $('#loginbox').show()">Sign In</a></div>--%>
                        </div>  
                        <div class="panel-body" >
                            <form id="signupform" class="form-horizontal" role="form" runat="server">
                                
                                <div id="signupalert" style="display:none" class="alert alert-danger">
                                    <p>Error:</p>
                                    <span></span>
                                </div>
                                    
                                
                                  
                                <div class="form-group">
                                    <label for="email" class="col-md-3 control-label">Email</label>
                                    <div class="col-md-9">
                                        <%--<input type="text" class="form-control" name="email" placeholder="Email Address">--%>
                                        <asp:textbox class="form-control" id="SignUpEmailtxt" placeholder="Email Address" runat="server" textmode="Email"></asp:textbox>
                                    </div>
                                </div>
                                    
                                <div class="form-group">
                                    <label for="username" class="col-md-3 control-label">Username</label>
                                    <div class="col-md-9">
                                        <%--<input type="text" class="form-control" name="username" placeholder="User Name">--%>
                                        <asp:textbox class="form-control" id="SignUpUsertxt" placeholder="Username" runat="server" ></asp:textbox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="password" class="col-md-3 control-label">Password</label>
                                    <div class="col-md-9">
                                        <%--<input type="password" class="form-control" name="passwd" placeholder="Password">--%>
                                        <asp:textbox class="form-control" id="SignUpPasstxt" placeholder="Password" runat="server" textmode="Password"></asp:textbox>
                                    </div>
                                </div>
                                    
                                <div class="form-group">
                                    <!-- Button -->                                        
                                    <div class="col-md-offset-3 col-md-9">
                                        <%--<button id="btn-signup" type="button" class="btn btn-info"><i class="icon-hand-right"></i> &nbsp Sign Up</button>--%>
                                        <asp:button cssclass="btn btn-info" id="btnsignup" onclick="RegisterUser" runat="server" text="Sign Up"></asp:button>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12 control">
                                        <div style="border-top: 1px solid#888; padding-top:15px; font-size:85%" >
                                            Already have an account?
                                        <asp:Button ID="SignInBtn" runat="server" OnClick="SignInButton_Click" Text="Sign in Here!" />
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