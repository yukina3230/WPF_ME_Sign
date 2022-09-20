SELECT count(priority_name)
from me_priority
where role_id = :roleId
    and priority_name in (
        'CreateFormView',
        'SendMailView',
        'QuerySignView'
    )