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
  <jsp:include page="/WEB-INF/bootstrap.html"/>
</head>
<body class="container">
<%--<c:forEach var="p" items="${persons}" >--%>
<%--    <p>- ${p.firstName} ${p.lastName} : ${p.age} ans</p>--%>
<%--</c:forEach>--%>

<c:if test="${cats.size() > 0}">

<table class="table">
  <thead>
  <tr>
    <th scope="col">#</th>
    <th scope="col">Nom</th>
    <th scope="col">Race</th>
    <th scope="col">Plat favori</th>
    <th scope="col">Date de naissance</th>
  </tr>
  </thead>
  <tbody>
  <c:forEach var="c" items="${cats}" varStatus="loop" >
    <tr>
      <th scope="row">${loop.index+1}</th>
      <td>${c.name}</td>
      <td>${c.breed}</td>
      <td>${c.food}</td>
      <td>${c.birthday}</td>
    </tr>
  </c:forEach>
  </tbody>
</table>
</c:if>
<c:if test="${cats.size() == 0}">
  <p>Aucun chat dans la liste :(</p>
</c:if>

<form action="cat" method="post">
  <div>
    <label for="name">Nom :</label>
    <input type="text" id="name" name="name">
  </div>
  <div>
    <label for="breed">Race :</label>
    <input type="text" id="breed" name="breed">
  </div>
  <div>
    <label for="food">Plat favori :</label>
    <input type="text" id="food" name="food">
  </div>
  <div>
    <label for="birthday">Date de naissance :</label>
    <input type="date" id="birthday" name="birthday">
  </div>
  <button>Ajouter</button>
  <button type="reset">Annuler</button>
</form>

</body>
</html>