# Generated by Django 5.0.7 on 2024-07-16 21:38

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('api', '0003_alter_cartitem_quantity_and_more'),
    ]

    operations = [
        migrations.RenameField(
            model_name='product',
            old_name='regular_price',
            new_name='base_price',
        ),
    ]
