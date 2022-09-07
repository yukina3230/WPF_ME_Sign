insert into me_signer (sign_id, user_id, create_date)
values (
        :sign_id,
        :user_id,
        to_date(:create_date, 'ddMMyyyy')