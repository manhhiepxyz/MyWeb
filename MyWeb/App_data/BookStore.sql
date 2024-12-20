SELECT 
    o.id AS OrderId,
    u.fullname AS CustomerName,
    s.address AS ShippingAddress,
    o.payment_id AS PaymentId,
    p.method AS PaymentMethod,
    o.toltalprice AS TotalPrice,
    s.status AS OrderStatus,
    s.date AS OrderDate,
    pr.name AS ProductName,
    oi.quantity AS Quantity,
    oi.price AS UnitPrice
FROM tblorder o
JOIN tbluser u ON o.user_id = u.id
JOIN tblshipment s ON o.shipment_id = s.id
JOIN tblpayment p ON o.payment_id = p.id
JOIN tblorderiteam oi ON o.id = oi.order_id
JOIN tblproduct pr ON oi.product_id = pr.id
ORDER BY o.id;
