/*1. Obtener todos los datos de todos los empleados (incluir el nombre del
departamento).*/
SELECT E.EMPNO, E.ENAME, E.JOB, E.MGR, E.HIREDATE, E.SAL, E.COMM, E.DEPTNO,  D.DNAME
FROM emp E, dept D
WHERE E.DEPTNO = D.DEPTNO
ORDER BY E.ENAME;
/*2. Obtener todos los datos de todos los departamentos.*/
SELECT DEPTNO, DNAME, LOC
FROM dept
ORDER BY DEPTNO;
/*3. Obtener todos los datos de los empleados cuyo trabajo es, 'CLERK'*/
SELECT EMPNO, ENAME, JOB, MGR, HIREDATE, SAL, COMM, DEPTNO
FROM emp
WHERE JOB LIKE '%CLERK%'
ORDER BY EMPNO;
/*4. Igual que el punto anterior (Idem), pero ordenado por el nombre.*/
SELECT EMPNO, ENAME, JOB, MGR, HIREDATE, SAL, COMM, DEPTNO
FROM emp
WHERE JOB LIKE '%CLERK%'
ORDER BY ENAME;
/*5. Obtener el mismo resultado de la pregunta anterior, pero modificando la
sentencia SQL al no nombrar la columna ename.*/
SELECT EMPNO, JOB, MGR, HIREDATE, SAL, COMM, DEPTNO
FROM emp
WHERE JOB LIKE '%CLERK%'
ORDER BY ENAME;
/*6. Obtener el número (codigo), nombre y salario de los empleados.*/
SELECT EMPNO, ENAME, SAL
FROM emp
ORDER BY EMPNO;
/*7. Lista los nombres de todos los departamentos de manera Z-A*/
SELECT DNAME
FROM dept
ORDER BY DNAME DESC;
/*8. Idem, pero ordenándolos por localidad.*/
SELECT DNAME
FROM dept
ORDER BY LOC DESC;
/*9. Idem, pero ordenándolo por la ciudad (no se debe seleccionar la ciudad en
el resultado).*/
SELECT DNAME
FROM dept
ORDER BY LOC;
/*10.Obtener el nombre y empleo de todos los empleados, ordenado por salario*/
SELECT ENAME, JOB, SAL
FROM emp
ORDER BY SAL;
/*11.Obtener el nombre y empleo de todos los empleados, ordenado primero por
su trabajo y luego por su salario.*/
SELECT ENAME, JOB, SAL
FROM emp
ORDER BY JOB, SAL;
/*12.Idem, pero ordenando inversamente por empleo y normalmente por salario*/
SELECT ENAME, JOB, SAL
FROM emp
ORDER BY JOB DESC, SAL;
/*13.Obtener los salarios y las comisiones de los empleados del departamento 30*/
SELECT ENAME, SAL, COMM
FROM emp
WHERE DEPTNO LIKE '%30%'
ORDER BY SAL;
/*14.Idem, pero ordenado por comisión.*/
SELECT ENAME, SAL, COMM
FROM emp
WHERE DEPTNO LIKE '%30%'
ORDER BY COMM;