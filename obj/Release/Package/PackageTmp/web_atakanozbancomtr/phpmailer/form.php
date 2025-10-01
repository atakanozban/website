<?php
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

require 'src/Exception.php';
require 'src/PHPMailer.php';
require 'src/SMTP.php';

$isim = isset($_POST['isim']) ? htmlspecialchars($_POST['isim']) : null;
$subject = isset($_POST['subject']) ? htmlspecialchars($_POST['subject']) : null;
$email = isset($_POST['email']) ? htmlspecialchars($_POST['email']) : null;
$content = isset($_POST['mesaj']) ? htmlspecialchars($_POST['mesaj']) : null;

// Giriş kontrolleri
if (!$isim) {
    echo "Please fill your name-surname!";
    exit;
}

if (!$email || !filter_var($email, FILTER_VALIDATE_EMAIL)) {
    echo "Please enter a valid email address!";
    exit;
}

if (!$subject) {
    echo "Please enter a subject!";
    exit;
}

if (!$content) {
    echo "Please enter your message!";
    exit;
}

$mail = new PHPMailer(true);

try {
    $mail->SMTPDebug = 0;
    $mail->isSMTP();
    $mail->Host       = 'smtp.gmail.com';
    $mail->SMTPAuth   = true;
    $mail->Username   = 'atakandoganozban@gmail.com';
    $mail->Password   = 'odxv setp ofgk sutp';
    $mail->SMTPSecure = PHPMailer::ENCRYPTION_SMTPS;
    $mail->Port       = 465;

    $mail->CharSet    = 'UTF-8';
    $mail->setFrom('atakandoganozban@gmail.com', 'Request Collector');
    $mail->addAddress('ozbanatakan2@gmail.com', 'Request Recipient');
    $mail->addReplyTo($email, $isim);

    // Konu başlığı
    $mail->Subject = "[atakanozban.com.tr] New Website Contact Request - " . $subject;

    // Mesaj içeriği
    $mail->isHTML(true);
    $mail->Body = nl2br("
        <p>This form was filled and sent by <strong>{$isim}</strong>.</p>
        <p><strong>E-Mail address:</strong> {$email}</p>
        <p><strong>Subject:</strong> {$subject}</p>
        <p><strong>Message:</strong><br>{$content}</p>
    ");

    // Dosya ekleme
    if (isset($_FILES['attachment']) && $_FILES['attachment']['error'] == 0) {
        $allowedTypes = ['image/jpeg', 'image/png', 'application/pdf'];
        $fileType = $_FILES['attachment']['type'];

        if (!in_array($fileType, $allowedTypes)) {
            echo "Only these file formats can just upload: pdf, jpg and png!";
            exit;
        }

        $mail->addAttachment($_FILES['attachment']['tmp_name'], $_FILES['attachment']['name']);
    }

    $mail->send();
    echo "Your message sent, thanks!";
} catch (Exception $e) {
    echo "Message can't send. Error: {$mail->ErrorInfo}";
}
?>
