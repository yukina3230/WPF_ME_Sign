SELECT S.SIGN_ID AS SIGN_ID,
    S.FORM_USER_ID AS FORM_USER_ID,
    S.FORM_USER_NAME AS FORM_USER_NAME,
    TO_CHAR(S.CREATE_DATE, 'dd/MM/yyyy') AS FORM_SIGN_DATE,
    SN.USER_ID AS USER_SIGN_ID,
    US.USER_NAME AS USER_NAME,
    US.ROLE_ID AS ROLE_ID,
    DP.DEPARTMENT_NAME AS DEPARTMENT_NAME,
    TO_CHAR(SN.CREATE_DATE, 'dd/MM/yyyy') AS SIGN_DATE
FROM ME_SIGN S
    LEFT JOIN ME_DEPARTMENT DP ON DP.DEPARTMENT_ID = S.DEPARTMENT_ID
    LEFT JOIN ME_USER US ON US.USER_ID = S.FORM_USER_ID
    LEFT JOIN ME_ROLE RO ON RO.ROLE_ID = US.ROLE_ID
    LEFT JOIN ME_SIGNER SN ON SN.SIGN_ID = S.SIGN_ID
WHERE S.SIGN_ID = :signId