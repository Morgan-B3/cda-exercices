<%--
  Created by IntelliJ IDEA.
  User: Administrateur
  Date: 29/07/2025
  Time: 12:25
  To change this template use File | Settings | File Templates.
--%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
    <jsp:include page="WEB-INF/bootstrap.html"/>
</head>
<body class="container">
<%--<c:forEach var="p" items="${persons}" >--%>
<%--    <p>- ${p.firstName} ${p.lastName} : ${p.age} ans</p>--%>
<%--</c:forEach>--%>

<table class="table">
    <thead>
    <tr>
        <th scope="col">#</th>
        <th scope="col">Prénom</th>
        <th scope="col">Nom</th>
        <th scope="col">Age</th>
    </tr>
    </thead>
    <tbody>
    <c:forEach var="p" items="${persons}" varStatus="loop" >
        <tr>
            <th scope="row">${loop.index+1}</th>
            <td>${p.firstName}</td>
            <td>${p.lastName}</td>
            <td>${p.age} ans</td>
        </tr>
    </c:forEach>
    </tbody>
</table>
</body>
</html>
