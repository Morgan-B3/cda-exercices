<%--
  Created by IntelliJ IDEA.
  User: Administrateur
  Date: 30/07/2025
  Time: 14:37
  To change this template use File | Settings | File Templates.
--%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<jsp:useBean id="dog" class="com.example.exercice4.model.Dog" scope="request" />
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>${dog.name}</title>
    <jsp:include page="/WEB-INF/bootstrap.html"/>
</head>
<body>

<h1>Voici le chien : ${dog.name}</h1>

</body>
</html>
