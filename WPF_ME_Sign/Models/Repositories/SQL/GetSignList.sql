select sign_id,
    project_title,
    to_char(me_sign.create_date, 'dd/Mm/yyyy') as create_date,
    form_user_id,
    form_user_name,
    department_name
from me_sign
    left join me_department on me_sign.department_id = me_department.department_id
where status_sign = 'N'