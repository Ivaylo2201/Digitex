# Generated by Django 5.0.7 on 2024-07-16 21:53

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('api', '0004_rename_regular_price_product_base_price'),
    ]

    operations = [
        migrations.RenameField(
            model_name='order',
            old_name='price',
            new_name='total_price',
        ),
    ]
