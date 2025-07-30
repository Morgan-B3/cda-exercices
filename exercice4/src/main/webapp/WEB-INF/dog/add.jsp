<%--
  Created by IntelliJ IDEA.
  User: Administrateur
  Date: 30/07/2025
  Time: 14:17
  To change this template use File | Settings | File Templates.
--%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<jsp:useBean id="dogList" type="java.util.ArrayList<com.example.exercice4.model.Dog>" scope="request" />
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<html>
<head>
    <title>Title</title>
    <jsp:include page="/WEB-INF/bootstrap.html"/>
</head>
<body>

<main class="container">
    <h1>Liste de Chiens</h1>
    <hr>

    <c:if test="${dogList.size() > 0}">
        <table class="table table-dark text-center align-middle">
            <thead>
            <tr>
                <th>Nom</th>
                <th>Race</th>
                <th>Date de naissance</th>
            </tr>
            </thead>
            <tbody>
            <c:forEach var="c" items="${dogList}" >
                <tr>
                    <td><a href="${pageContext.request.contextPath}/dog/show?id=${c.id}">${c.name}</a></td>
                    <td>${c.breed}</td>
                    <td>${c.dateOfBirth}</td>
                </tr>
            </c:forEach>
            </tbody>
        </table>
    </c:if>

    <c:if test="${dogList.size() == 0}">
        <p>Aucun chien dans la liste :(</p>
    </c:if>

    <hr>

    <h2>Ajouter un chien</h2>

    <form action="${pageContext.request.contextPath}/dog/add" method="post">
        <div>
            <label for="name">Nom :</label>
            <input type="text" id="name" name="name">
        </div>
        <div>
            <label for="breed">Race :</label>
            <input type="text" id="breed" name="breed">
        </div>
        <div>
            <label for="dateOfBirth">Date de Naissance :</label>
            <input type="date" id="dateOfBirth" name="dateOfBirth">
        </div>
        <button>Ajouter</button>
        <button type="reset">Annuler</button>
    </form>
</main>

</body>
</html>
