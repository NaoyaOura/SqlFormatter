SELECT
 X.*
FROM
 DOC_PARTITION X
,(   SELECT
     "fuga"
   , "HOGE"
   FROM DUAL
) Y
