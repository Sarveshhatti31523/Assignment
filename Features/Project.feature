Feature: WordPress

@positive
Scenario: Thoughts on recent posts
	   Given User Launch Chrome Browser
	   When User opens url  "https://www.salesforce.com/in/?ir=1"
	   And Hover on Product button and enter product as "Customer 360" and verify the content
	   Then verify the product as "Customer 360"
	 
@positive
Scenario: BitCoin
       Given User Launch Chrome Browser
       Given User Logs in Using "https://www.coindesk.com/price/bitcoin/"
	   When User hovers on chart , user enters date as "28 Dec 2021, 05:35 GMT+5:30" and able to see price

