 --Populate LU_TransactionType rows

 SET IDENTITY_INSERT [DataContext].[dbo].[LU_TransactionType]  ON

  Insert Into  [DataContext].[dbo].[LU_TransactionType] (TransactionTypeId, TransactionType)
  Values(1,'Deposit'),
  (2,'Withdrawl');

   SET IDENTITY_INSERT [DataContext].[dbo].[LU_TransactionType]  Off


    --Populate LU_TransactionType rows

 SET IDENTITY_INSERT [DataContext].[dbo].[LU_AccountType]  ON

  Insert Into  [DataContext].[dbo].[LU_AccountType] (AccountTypeId, AccountType)
  Values(1,'Checking'),
  (2,'Savings');

   SET IDENTITY_INSERT [DataContext].[dbo].[LU_AccountType]  Off