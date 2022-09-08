select sign_id,
    project_title,
    to_char(me_sign.create_date, 'dd/Mm/yyyy') as create_date,
    form_user_id,
    form_user_name,
    department_name,
    status_sign
from me_sign
    left join me_department on me_sign.department_id = me_department.department_id
where me_sign.create_date between to_date(:fromDate, 'dd/MM/yyyy') and to_date(:toDate, 'dd/MM/yyyy')