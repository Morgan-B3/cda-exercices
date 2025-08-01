<%--
  Created by IntelliJ IDEA.
  User: Administrateur
  Date: 01/08/2025
  Time: 14:45
  To change this template use File | Settings | File Templates.
--%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<jsp:useBean id="p" type="com.example.tp_hopital.model.Patient" scope="request" />
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>${p.firstName} ${p.lastName}</title>
    <jsp:include page="/WEB-INF/bootstrap.html"/>
</head>
<body>

<main class="container">
    <h1>${p.firstName} ${p.lastName}</h1>
    <p>Né le ${p.dob.getDayOfMonth()}/${p.dob.getMonthValue()}/${p.dob.getYear()}.</p>
    <img src="${pageContext.request.contextPath}/images/${p.imageURL}">

<%--    CONSULTATIONS    --%>

<%--    <c:if test="${p.consultations.size() > 0}">--%>
<%--        <table class="table table-dark text-center align-middle">--%>
<%--            <thead>--%>
<%--            <tr>--%>
<%--                <th>Référence</th>--%>
<%--                <th>Date de consultation</th>--%>
<%--                <th>Nom du médecin</th>--%>
<%--            </tr>--%>
<%--            </thead>--%>
<%--            <tbody>--%>
<%--            <c:forEach var="c" items="${p.consultations}" >--%>
<%--                <tr>--%>
<%--                    <td><a href="${pageContext.request.contextPath}/consultations/show?id=${c.id}">${c.id}</a></td>--%>
<%--                    <td>${c.date}</td>--%>
<%--                    <td>${c.doctorName}</td>--%>
<%--                </tr>--%>
<%--            </c:forEach>--%>
<%--            </tbody>--%>
<%--        </table>--%>
<%--    </c:if>--%>
<%--    <c:if test="${p.consultations.size() == 0}">--%>
<%--        <p>Aucune consultation actuellement</p>--%>
<%--    </c:if>--%>

    <jsp:include page="home.jsp"/>

</main>

</body>
</html>
