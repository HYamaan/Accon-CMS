import nodemailer from "nodemailer";

export default async function handler(req, res) {
    if (req.method === 'POST') {
        const { name, email, phone, message } = req.body;

        console.log("Received POST request with body: ", req.body);

        try {
            const transporter = nodemailer.createTransport({
                host: process.env.NODE_MAILER_HOST,
                port: process.env.NODE_MAILER_PORT,
                secure: process.env.NODE_MAILER_PORT == 465, // true for 465, false for other ports
                auth: {
                    user: process.env.NODE_MAILER_USER,
                    pass: process.env.NODE_MAILER_PASS,
                },
                tls: {
                    // do not fail on invalid certs
                    rejectUnauthorized: false
                }
            });

            console.log("SMTP transporter configured");

            const mailOption = {
                from: email,
                to: "hakanyaman5249@gmail.com, baz@example.com",
                subject: "New Contact Us Message",
                text: `Name: ${name}\nPhone: ${phone}\nMessage: ${message}`,
                html: `
                    <div style="font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ccc; border-radius: 10px;">
                        <h2 style="background-color: #f4f4f4; padding: 10px; text-align: center; border-radius: 10px 10px 0 0;">New Contact Us Message</h2>
                        <div style="padding: 20px;">
                            <p style="font-size: 16px;"><strong>Name:</strong> ${name}</p>
                            <p style="font-size: 16px;"><strong>Emai:</strong> ${email}</p>
                            <p style="font-size: 16px;"><strong>Phone:</strong> ${phone}</p>
                            <p style="font-size: 16px;"><strong>Message:</strong></p>
                            <p style="font-size: 14px; line-height: 1.5; padding: 10px; background-color: #f9f9f9; border-radius: 5px;">${message}</p>
                        </div>
                        <footer style="text-align: center; padding: 10px; font-size: 12px; color: #666;">
                            <p>Sent via Your Website Contact Form</p>
                        </footer>
                    </div>
                `,
            };

            console.log("Mail options set: ", mailOption);

            let info = await transporter.sendMail(mailOption);

            console.log("Message sent: %s", info.messageId);
            console.log("Preview URL: %s", nodemailer.getTestMessageUrl(info));

            return res.status(200).json({ message: 'Email sent successfully' });
        } catch (e) {
            console.error("Error sending email: ", e);
            return res.status(500).json({ error: e.message });
        }
    } else {
        res.setHeader('Allow', ['POST']);
        res.status(405).end(`Method ${req.method} Not Allowed`);
    }
}
