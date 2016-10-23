 --Populate LU_TransactionType rows

 SET IDENTITY_INSERT [DataContext].[dbo].[LU_TransactionType]  ON

  Insert Into  [DataContext].[dbo].[LU_TransactionType] (TransactionTypeId, TransactionType)
  Values(1,'Deposit'),
  (2,'Withdrawl');

   SET IDENTITY_INSERT [DataContext].[dbo].[LU_TransactionType]  Off