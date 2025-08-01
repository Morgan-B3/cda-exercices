<%--
  Created by IntelliJ IDEA.
  User: Administrateur
  Date: 01/08/2025
  Time: 14:37
  To change this template use File | Settings | File Templates.
--%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<jsp:useBean id="patients" type="java.util.ArrayList<com.example.tp_hopital.model.Patient>" scope="request" />
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Patients</title>
    <jsp:include page="/WEB-INF/bootstrap.html"/>
</head>
<body>

<main class="container">
    <c:if test="${patients.size() > 0}">
        <table class="table table-dark text-center align-middle">
            <thead>
            <tr>
                <th>Nom</th>
                <th>Date de naissance</th>
            </tr>
            </thead>
            <tbody>
            <c:forEach var="p" items="${patients}" >
                <tr>
                    <td><a href="${pageContext.request.contextPath}/patients/show?id=${p.id}">${p.firstName} ${p.lastName}</a></td>
                    <td>${p.dob}</td>
                </tr>
            </c:forEach>
            </tbody>
        </table>
    </c:if>

    <c:if test="${patients.size() == 0}">
        <p>Aucun patient actuellement</p>
    </c:if>

    <hr>

    <h2>Ajouter un patient</h2>

    <form action="${pageContext.request.contextPath}/patients/add" method="post" enctype="multipart/form-data">
        <div>
            <label for="firstName">Prénom :</label>
            <input type="text" id="firstName" name="firstName">
        </div>
        <div>
            <label for="lastName">Nom :</label>
            <input type="text" id="lastName" name="lastName">
        </div>
        <div>
            <label for="dob">Date de Naissance :</label>
            <input type="date" id="dob" name="dob">
        </div>
        <div>
            <label for="image">Photo :</label>
            <input type="file" id="image" name="image">
        </div>
        <button>Ajouter</button>
        <button type="reset">Annuler</button>
    </form>
    <jsp:include page="home.jsp"/>
</main>
</body>
</html>
