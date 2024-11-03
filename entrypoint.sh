
#!/bin/bash

# Start Keycloak in the background
/opt/keycloak/bin/kc.sh start-dev &

# Wait for Keycloak to start
echo "Waiting for Keycloak to start..."
until curl -s http://localhost:8080/auth/realms/master; do
  sleep 5
done
echo "Keycloak has started."

# Use kcadm.sh to update the realm setting
/opt/keycloak/bin/kcadm.sh config credentials --server http://localhost:8080/auth --realm master --user "$KEYCLOAK_ADMIN" --password "$KEYCLOAK_ADMIN_PASSWORD"
/opt/keycloak/bin/kcadm.sh update realms/master -s sslRequired=NONE

# Keep the container running
wait

