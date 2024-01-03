You will create an webapi for bank payment systems.

Functional requirements:

<del> 1. You should be able to create an user (name, address)</del>

<del> 3. You should be able to create an account for a user.</del>
  
<del> 5. User can only have max 2 accounts.</del>
  
<del> 7. Account can have a type "Saving"/"Default" and a balance.</del>
  
<del> 9. You should be able to topup an account.</del>
 
11. User should be able to send money to another user. Lets call it transaction
  
<del> 7. It should be possible to retrieve all transaction information for an account:
    I need to be able (given userid), tops, money sent, received.</del>
   
9. Transaction costs 1 euro.

**Notes:**
- when returning transactions by user, we also return transactions of deleted users/accounts (for audit purposes).



Personal improvement ideas: 
- full crud (for troubleshooting/testing)
- add indices
- "transfer money" -> from default -> if not enough money, from savings
