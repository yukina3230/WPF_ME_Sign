insert into me_user (
        me_user_id,
        user_id,
        password,
        user_name,
        dept,
        email,
        role_id,
        create_date,
        status
    )
values (
        seq_me_user_id.nextval,
        :userId,
        :password,
        :userName,
        :dept,
        :email,
        :roleId,
        to_date(:create_date, 'ddMMyyyy'),
        :status
    )