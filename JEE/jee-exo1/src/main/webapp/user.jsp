<%--
  Created by IntelliJ IDEA.
  User: Administrateur
  Date: 29/07/2025
  Time: 09:51
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<jsp:useBean id="nom" type="java.lang.String" scope="request" />
<jsp:useBean id="color" type="java.lang.String" scope="request" />
<html>
<head>
    <title>Title</title>
    <jsp:include page="WEB-INF/bootstrap.html"/>
</head>
<body class="<%= color%>">

<h1><%= nom%></h1>

<jsp:include page="WEB-INF/homeBack.jsp"/>
</body>
</html>
