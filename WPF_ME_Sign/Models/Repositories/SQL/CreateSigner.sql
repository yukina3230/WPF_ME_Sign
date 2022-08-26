INSERT INTO 
ME_SIGNER
  ( Signer_Serial_Key,
    User_ID,
    Sign_ID ,
    Create_Date ) 
VALUES
  ( seq_me_signer_id.nextval,        
    :user_id,
    (select max(sign_id) from me_sign),
    to_date(:create_date, 'ddMMyyyy')   
  ) 
